Feature: BooksPut
	
Scenario Outline: Update book 
	Given I create a new Book (<Id>, James Herbert, The Rats, Scary book about giant rats)
	When I update <PropertyToUpdate> with <NewValue>
	Then the system should return <StatusCode> 
	And the response body should contain the expected book object

Examples:
	| Id  | PropertyToUpdate | NewValue                  | StatusCode |
	| 300 | Author           | Updated Author            | 200        |
	| 301 | Title            | Updated Title             | 200        |
	| 302 | Description      | Updated Description       | 200        |
	| 303 | Author           | !\"£$%^&*()',./<>?\\`_+-= | 200        |
	| 304 | Title            | !\"£$%^&*()',./<>?\\`_+-= | 200        |
	| 305 | Description      | !\"£$%^&*()',./<>?\\`_+-= | 200        |

Scenario Outline: Update book succeeds where a property is updated to its max allowed size
	Given I create a new Book (<Id>, James Herbert, The Rats, Scary book about giant rats)
	When I update <PropertyToUpdate> with <NewValue>
	Then the system should return <StatusCode> 
	And the response body should contain the expected book object

Examples:
	| Id  | PropertyToUpdate | NewValue                                                                                                                                                                                                 | StatusCode |
	| 306 | Author           | 123456789012345678901234567MAX                                                                                                                                                                           | 200        |
	| 307 | Title            | 1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890                                                                                                     | 200        |
	| 308 | Description      | 12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890 | 200        |

Scenario Outline: Update book fails where a property is updated to exceed its max allowed size
	Given I create a new Book (<Id>, James Herbert, The Rats, Scary book about giant rats)
	When I update <PropertyToUpdate> with <NewValue>
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id  | PropertyToUpdate | NewValue                                                                                              | StatusCode | ErrorMessage                                 |
	| 309 | Author           | 123456789012345678901234567MAX1                                                                       | 400        | Book.Author should not exceed 30 characters! |
	| 310 | Title            | 12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901 | 400        | Book.Title should not exceed 100 characters! |

Scenario Outline: Update book fails when attempting to update Id
	Given I create a new Book (<Id>, James Herbert, The Rats, Scary book about giant rats)
	When I update <PropertyToUpdate> with <NewValue>
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id  | PropertyToUpdate | NewValue | StatusCode | ErrorMessage               |
	| 312 | Id               | 399      | 400        | Book.Id cannot be updated! |

Scenario Outline: Update book succeeds when Description is omitted from the request body
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	When I omit Description from an update request
	Then the system should return <StatusCode> 
	And Description still has its original value of <Description> 

Examples:
	| Id  | Author        | Title    | Description                 | StatusCode |
	| 313 | James Herbert | The Rats | Scary book about giant rats | 200        |

Scenario Outline: Update book fails when Author is omitted from the request body
	Given I create a new Book (<Id>, James Herbert, The Rats, Scary book about giant rats)
	When I omit Author from an update request
	Then the system should return <StatusCode> 
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id  | StatusCode | ErrorMessage                    |
	| 314 | 400        | Book.Author is a required field |
	
Scenario Outline: Update book fails when Title is omitted from the request body
	Given I create a new Book (<Id>, James Herbert, The Rats, Scary book about giant rats)
	When I omit Title from an update request
	Then the system should return <StatusCode> 
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id  | StatusCode | ErrorMessage                   |
	| 315 | 400        | Book.Title is a required field |

		
Scenario Outline: Update book fails when Id is omitted from the request body
	Given I create a new Book (<Id>, James Herbert, The Rats, Scary book about giant rats)
	When I omit Id from an update request
	Then the system should return <StatusCode> 
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id  | StatusCode | ErrorMessage                          |
	| 316 | 400        | Book.Id should be a positive integer! |
