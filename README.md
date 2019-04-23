# Dog Information Api

 - A simple ASP.NET Web API service for Dog Information.
 - Swashbuckle is used for display purposes, endpoint testing, sample json data, and simple documentation.
 - There are five simple endpoints used for Creating, Reading, Reading All, Updating, and Deleting the Dog information.
 - A sample dog is given within the "dogs.json" file within the project.

# Using the API
 - This API was built using Visual Studio 2017. When built/ran it will navigate to the Swashbuckle page for a basic documentation of the API. All of the following instructions can also be found on the Swashbuckle page in more detail. Note: the ID within the URL and the Dog Json objects must match.
 - It is strongly recommended to use the Swashbuckle documentation page for endpoint testing, and example data sets.
   * Creating a new set of Dog Information. POST https://localhost:44345/api/Dogs with a Dog object in the body.
   * Retrieving all dogs. GET https://localhost:44345/api/Dogs
   * Retrieving a single dog. GET https://localhost:44345/api/Dogs/{id} with the ID of the dog in the url
   * Updating a single dog. PUT https://localhost:44345/api/Dogs/{id} with the ID of the dog in the url, and the dog json object in the body.
   * Deleting a single dog. DELETE https://localhost:44345/api/Dogs/{id} with the ID of the dog in the url
