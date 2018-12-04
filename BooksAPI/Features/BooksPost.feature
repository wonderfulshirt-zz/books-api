Feature: BooksPost
	
Scenario Outline: Add book
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	Then the system should return <StatusCode>
	And the response body should contain the expected book object

Examples:
	| Id | Author                    | Title                     | Description                 | StatusCode |
	| 1  | James Herbert             | The Rats                  | Scary book about giant rats | 200        |
	| 2  | !\"£$%^&*()',./<>?\\`_+-= | Special chars             | Special chars               | 200        |
	| 3  | Special chars             | !\"£$%^&*()',./<>?\\`_+-= | Special chars               | 200        |
	| 4  | Special chars             | Special chars             | !\"£$%^&*()',./<>?\\`_+-=   | 200        |

Scenario Outline: Add book succeeds when Description is omitted from the request body
Given I create a new Book with no Description (<Id>, <Author>, <Title>)
Then the system should return <StatusCode>

Examples:
	| Id | Author        | Title    | StatusCode |
	| 5  | James Herbert | The Rats | 200        |

Scenario Outline: Add book succeeds where a property is its max allowed size
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	Then the system should return <StatusCode>
	And the response body should contain the expected book object

Examples:
	| Id         | Author                         | Title                                                                                                | Description                                                                                                                                                                                              | StatusCode |
	| 7          | 123456789012345678901234567MAX | The 39 Steps                                                                                         | Author Max length                                                                                                                                                                                        | 200        |
	| 8          | Terry Pratchett                | 1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890 | Title Max length                                                                                                                                                                                         | 200        |
	| 9          | Dean R Koontz                  | No max length for Decription in the spec but for good measure... 100 chars                           | 12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890 | 200        |
	| 2147483647 | Max Int32                      | The Big Number Book                                                                                  | Scary book about giant rats                                                                                                                                                                              | 200        |


Scenario Outline: Add book fails where a property exceeds its max allowed length
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id | Author                          | Title                                                                                                 | Description           | StatusCode | ErrorMessage                                 |
	| 11 | 1234567890123456789012345678901 | Test title                                                                                            | Author Max length + 1 | 400        | Book.Author should not exceed 30 characters! |
	| 12 | Test author                     | 12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901 | Title Max length + 1  | 400        | Book.Title should not exceed 100 characters! |

Scenario Outline: Add book fails where the value of Id is greater than Int32 max value
	Given I create a new Book with an Id greater than Int32 max value
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| StatusCode | ErrorMessage                                                                                   |
	| 400        | Expecting a message relating to the value of Book.Id. Instead I get 'Book should be provided!' |

Scenario Outline: Add book fails when Id is omitted from the request body
	Given I create a new Book with no Id (<Author>, <Title>, <Description>)
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Author      | Title      | Description      | StatusCode | ErrorMessage                          |
	| Test author | Test title | Test description | 400        | Book.Id should be a positive integer! |

Scenario Outline: Add book fails when Author is omitted from the request body
	Given I create a new Book with no Author (<Id>, <Title>, <Description>)
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id | Title      | Description      | StatusCode | ErrorMessage                    |
	| 20 | Test title | Test description | 400        | Book.Author is a required field |

Scenario Outline: Add book fails when Title is omitted from the request body
	Given I create a new Book with no Title (<Id>, <Author>, <Description>)
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id | Author      | Description      | StatusCode | ErrorMessage                   |
	| 21 | Test Author | Test description | 400        | Book.Title is a required field |

Scenario Outline: Add book fails when Id is a negative integer
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id | Author      | Title      | Description      | StatusCode | ErrorMessage                          |
	| -1 | Test author | Test title | Test description | 400        | Book.Id should be a positive integer! |

Scenario Outline: Adding a second book with the same ID fails
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	And I create a new Book (<Id>, <Author>, <Title>, <Description>)
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id | Author      | Title      | Description      | StatusCode | ErrorMessage                    |
	| 99 | Test author | Test title | Test description | 400        | Book with id 99 already exists! |
