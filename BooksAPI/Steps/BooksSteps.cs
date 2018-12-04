using System;
using TechTalk.SpecFlow;
using BooksAPI.Model;
using System.Net.Http;
using System.Text;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace BooksAPI.Steps
{
    [Binding]
    public class BooksSteps
    {
        private Book _book;
        private int statusCode;
        private static readonly HttpClient client = new HttpClient();
        private string host = "http://localhost:9000";
        HttpResponseMessage result;
        string responseString;
        dynamic responseAsJson;
        dynamic responseAsJsonArray;

        [Given(@"I create a new Book \((.*), (.*), (.*), (.*)\)")]
        public void GivenICreateANewBook(int id, string author, string title, string description)
        {
            _book = new Book()
            {
                Id = id,
                Author = author,
                Title = title,
                Description = description
            };
            
            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books";
            result = client.PostAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [Given(@"I create a new Book with an Id greater than Int32 max value")]
        public void GivenICreateANewBookWithAnIdGreaterThanInt32MaxValue()
        {
            string book = "{\"Id\": 2147483648,\"Author\" = author,\"Title\" = \"title\",\"Description\" = \"description\"}";

            string content = JsonConvert.SerializeObject(book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books";
            result = client.PostAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [Given(@"I create a new Book with no Id \((.*), (.*), (.*)\)")]
        public void GivenICreateANewBookWithNoId(string author, string title, string description)
        {
            _book = new Book()
            {
                Author = author,
                Title = title,
                Description = description
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books";
            result = client.PostAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [Given(@"I create a new Book with no Author \((.*), (.*), (.*)\)")]
        public void GivenICreateANewBookWithNoAuthor(int id, string title, string description)
        {
            _book = new Book()
            {
                Id = id,
                Title = title,
                Description = description
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books";
            result = client.PostAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [Given(@"I create a new Book with no Title \((.*), (.*), (.*)\)")]
        public void GivenICreateANewBookWithNoTitle(int id, string author, string description)
        {
            _book = new Book()
            {
                Id = id,
                Author = author,
                Description = description
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books";
            result = client.PostAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [Given(@"I create a new Book with no Description \((.*), (.*), (.*)\)")]
        public void GivenICreateANewBookWithNoDescription(int id, string author, string title)
        {
            _book = new Book()
            {
                Id = id,
                Author = author,
                Title = title
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books";
            result = client.PostAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [When(@"I update (.*) with (.*)")]
        public void WhenIUpdatePropertyWithNewValue(string property, string newValue)
        {
            int requestId = _book.Id;
            int newId = _book.Id;
            string newAuthor = _book.Author;
            string newTitle = _book.Title;
            string newDescription = _book.Description;

            if(property == "Id")
            {
                newId = Int32.Parse(newValue);
            }
            else if(property == "Author")
            {
                newAuthor = newValue;
            }
            else if(property == "Title")
            {
                newTitle = newValue;
            }
            else if(property == "Description")
            {
                newDescription = newValue;
            }

            _book = new Book()
            {
                Id = newId,
                Author = newAuthor,
                Title = newTitle,
                Description = newDescription
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            string url = host + "/api/books/" + requestId;
            result = client.PutAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [When(@"I omit Description from an update request")]
        public void WhenIOmitDescriptionFromAnUpdateRequest()
        {
            _book = new Book()
            {
                Id = _book.Id,
                Author = "Updated Author",
                Title = "Updated Title"
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            string url = host + "/api/books/" + _book.Id;
            result = client.PutAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [When(@"I omit Author from an update request")]
        public void WhenIOmitAuthorFromAnUpdateRequest()
        {
            _book = new Book()
            {
                Id = _book.Id,
                Title = "Updated Title",
                Description = "Updated Description"
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books/" + _book.Id;
            result = client.PutAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [When(@"I omit Title from an update request")]
        public void WhenIOmitTitleFromAnUpdateRequest()
        {
            _book = new Book()
            {
                Id = _book.Id,
                Author = "Updated Author",
                Description = "Updated Description"
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books/" + _book.Id;
            result = client.PutAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [When(@"I omit Id from an update request")]
        public void WhenIOmitIdFromAnUpdateRequest()
        {
            _book = new Book()
            {
                Author = "Updated Author",
                Title = "Updated Title",
                Description = "Updated Description"
            };

            string content = JsonConvert.SerializeObject(_book);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = host + "/api/books/" + _book.Id;
            result = client.PutAsync(url, byteContent).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [Given(@"I get the book by ID (.*)")]
        [When(@"I get the book by ID (.*)")]
        public void WhenIGetTheBookByID(int id)
        {
            string url = host + "/api/books/" + id;
            result = client.GetAsync(url).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJson = JObject.Parse(responseString);
        }

        [Given(@"I delete the book by ID (.*)")]
        [When(@"I delete the book by ID (.*)")]
        public void WhenIDeleteTheBookByID(int id)
        {
            string url = host + "/api/books/" + id;
            result = client.DeleteAsync(url).Result;
            statusCode = (Int32)result.StatusCode;

            responseString = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine("resp: " + responseString.Length);

            if(responseString.Length > 0)
            {
                responseAsJson = JObject.Parse(responseString);
            }
        }

        [When(@"I get books with Title containing (.*)")]
        public void WhenIGetBooksWithTitleContaining(string searchTerm)
        {
            string url = host + "/api/books?title=\"" + searchTerm + "\"";
            result = client.GetAsync(url).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJsonArray = JsonConvert.DeserializeObject(responseString);
        }

        [When(@"I get all books")]
        public void WhenIGetAllBooks()
        {
            string url = host + "/api/books";
            result = client.GetAsync(url).Result;
            statusCode = (Int32)result.StatusCode;
            responseString = result.Content.ReadAsStringAsync().Result;
            responseAsJsonArray = JsonConvert.DeserializeObject(responseString);
        }

        [Then(@"the system should return (.*)")]
        public void ThenTheSystemShouldReturn(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, statusCode);
        }
        
        [Then(@"the response body should contain the expected book object")]
        public void ThenTheResponseBodyShouldContainTheExpectedBookObject()
        {
            Assert.AreEqual(_book.Id, (int)responseAsJson.Id);
            Assert.AreEqual(_book.Title, (string)responseAsJson.Title);
            Assert.AreEqual(_book.Description, (string)responseAsJson.Description);
            Assert.AreEqual(_book.Author, (string)responseAsJson.Author);
        }

        [Then(@"the response body should contain a valid book object")]
        public void ThenTheResponseBodyShouldContainAValidBookObject()
        {
            Assert.IsTrue(responseAsJson.Id.Type.ToString().Equals("Integer"));
            Assert.AreEqual(_book.Author.GetType().Name.ToString(), responseAsJson.Author.Type.ToString());
            Assert.AreEqual(_book.Title.GetType().Name.ToString(), responseAsJson.Title.Type.ToString());
            Assert.AreEqual(_book.Description.GetType().Name.ToString(), responseAsJson.Description.Type.ToString());
        }

        [Then(@"the error response should contain the message (.*)")]
        public void ThenTheErrorResponseShouldContainTheMessage(string expectedMessage)
        {
            string actualMessage = (string)responseAsJson.Message;
            Assert.IsTrue(actualMessage.Contains(expectedMessage), actualMessage + " doesn't contain " + expectedMessage);
        }

        [Then(@"the response body should contain the requested book Id (.*)")]
        public void ThenTheResponseBodyShouldContainTheRequestedBookId(int id)
        {
            Assert.AreEqual(id, (int)responseAsJson.Id);
        }

        [Then(@"the response body should only contain (.*) books")]
        public void ThenTheResponseBodyShouldOnlyContainNumberOfBooks(int numberOfBooks)
        {
            Assert.AreEqual(numberOfBooks, responseAsJsonArray.Count);
        }

        [Then(@"the response body should only contain results where Title contains (.*)")]
        public void ThenTheResponseBodyShouldOnlyContainResultsWhereTitleContains(string searchTerm)
        {
            foreach (JObject book in responseAsJsonArray)
            {
                string title = (string)book.GetValue("Title");
                Assert.IsTrue(title.Contains(searchTerm), title + " doesn't contain " + searchTerm);
            }
        }

        [Then(@"the response body should contain at least (.*) books")]
        public void ThenTheResponseBodyShouldContainAtLeastBooks(int minimumNumberOfBooks)
        {
            Assert.IsTrue(minimumNumberOfBooks <= responseAsJsonArray.Count, minimumNumberOfBooks + " is not <= to " + responseAsJsonArray.Count);
        }

        [Then(@"Description still has its original value of (.*)")]
        public void ThenDescriptionStillHasItsOriginalValueOf(string description)
        {
            Assert.AreEqual(description, (string)responseAsJson.Description);
        }
    }
}
