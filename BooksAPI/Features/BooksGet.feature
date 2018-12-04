Feature: BooksGet
	
Scenario Outline: Get a book by ID returns a valid book object
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	When I get the book by ID <Id>
	Then the system should return <StatusCode>
	And the response body should contain a valid book object

Examples:
	| Id  | Author        | Title    | Description                 | StatusCode |
	| 100 | James Herbert | The Rats | Scary book about giant rats | 200        |

Scenario Outline: Get a book by ID returns the correct book
	Given I create a new Book (101, Test author, Test title, Test description)
	And I create a new Book (<Id>, <Author>, <Title>, <Description>)
	When I get the book by ID <Id>
	Then the system should return <StatusCode>
	And the response body should contain the requested book Id <Id>

Examples:
	| Id  | Author        | Title    | Description                 | StatusCode |
	| 102 | James Herbert | The Rats | Scary book about giant rats | 200        |

Scenario Outline: Get a book by ID that does not exist returns a 404
	Given I get the book by ID <Id>
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id      | StatusCode | ErrorMessage                    |
	| 9999999 | 404        | Book with id 9999999 not found! |

Scenario Outline: Get books with a title that matches the query string returns the correct book
	Given I create a new Book (102, Author One, A Query title, Description One)
	And I create a new Book (103, Author Two, No match, Description Two)
	And I create a new Book (104, Author Three, Title of Query, Description Three)
	When I get books with Title containing <SearchTerm>
	Then the system should return 200
	And the response body should only contain <NumberOfMatchingBooks> books
	And the response body should only contain results where Title contains <SearchTerm>

Examples:
	| NumberOfMatchingBooks | SearchTerm |
	| 2                     | Query      |
	| 1                     | match      |

Scenario Outline: Get all books
	Given I create a new Book (105, Author One, Title One, Description One)
	And I create a new Book (106, Author Two, Title Two, Description Two)
	And I create a new Book (107, Author Three, Title Three, Description Three)
	When I get all books
	Then the system should return 200
	And the response body should contain at least <MinimumNumberOfBooks> books

Examples:
	| MinimumNumberOfBooks |
	| 3                    |