Feature: BooksDelete

Scenario Outline: Delete a Book
	Given I create a new Book (<Id>, <Author>, <Title>, <Description>)
	When I delete the book by ID <Id>
	Then the system should return <StatusCode>

Examples:
	| Id  | Author        | Title    | Description                 | StatusCode |
	| 200 | James Herbert | The Rats | Scary book about giant rats | 204        |

Scenario Outline: Delete a book that does not exist returns a 404
	Given I delete the book by ID <Id>
	Then the system should return <StatusCode>
	And the error response should contain the message <ErrorMessage>

Examples:
	| Id      | StatusCode | ErrorMessage                    |
	| 9999999 | 404        | Book with id 9999999 not found! |