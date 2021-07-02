
$(document).ready(function () {
   LoadBooks();
});

/**
 * Load books into a dynamically generated using the GET method on the Web API
 */
function LoadBooks() {
   $.ajax({
      type: "GET",
      url: "https://localhost:44334/api/book",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
         let rowHtml = "";
         $.each(data, function (i, book) {
            let row =
               "<tr>" +
               "<td >" + book.name + "</td>" +
               "<td >" + book.author + "</td>" +
               "<td >" + book.category.categoryName + "</td>" +
               "<td >" + book.description + "</td>" +
               "<td >" + new Date(book.registrationTimeStamp).toLocaleDateString() + "</td>" +
               "<td>" +
               "  <div>" +

               " <button class='btn  btn-sm text-white' style='background-color: #168c6d !important;' onclick='EditBook(" + book.id + ")'>Edit</button>" +
               ` <button class='btn btn-outline-danger btn-sm text-white' style='' onclick='DeleteBook(${book.id} , "${book.name}")'><i class='bi bi-trash'></i></button>`+
                  "</div>" +
               
               "</td>" +
               "</tr>";
            rowHtml += row;
         });
         document.getElementById("booktableBody").innerHTML = rowHtml;
      },

      failure: function (data) {
         alert(data.responseText);
      },
      error: function (data) {
         alert(data.responseText);
      }

   });
}

/**
 * Create a book using the Create Web API and reload the table as well as clear create modal form fields
 */
function CreateBook() {
   //Ensure data is enter for all fields by user
   if (txtName.value == "" || txtAuthor.value == "" || selCategory.value == "" || txtDescription.value == "") {
      alert("Please fill in all fields before creating a new book.");
      return;
   }

   const createData = { "name": txtName.value, "author": txtAuthor.value, "registrationTimeStamp": new Date().toJSON().toString(), "categoryId": selCategory.value, "description": txtDescription.value };

   $.ajax({
      type: "POST",
      url: "https://localhost:44334/api/book/create",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(createData),
      success: function (data) {
         LoadBooks();
         $("#modalCreateForm").modal("hide");
         alert("New book id = " + JSON.stringify(data));

         //clear input fields
         txtName.value = "";
         txtAuthor.value = "";
         selCategory.value = "";
         txtDescription.value = "";

      },
      failure: function (data) {
         alert(data.responseText);
      },
      error: function (data) {
         alert(data.responseText);
      }
   });
}

/**
 * Load the selected book into the edit modal for the user to update and show the edit modal.
 */
function EditBook(bookId) {

   //Get book detail from API using Id 
   $.ajax({
      type: "GET",
      url: "https://localhost:44334/api/book/" + bookId,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {

         //Update edit form with get results
         txtEditName.value = data.name;
         txtEditDescription.value = data.description;
         txtEditAuthor.value = data.author;
         selEditCategory.value = data.category.id;
         txtEditBookId.value = data.id;

         $("#modalEditForm").modal("show");
      },

      failure: function (data) {
         alert(data.responseText);
      },
      error: function (data) {
         alert(data.responseText);
      }
   });
}

/**
 * Edit a book using the update Web API method and reload the table as well
 */
function UpdateBook() {


   if (txtEditName.value == "" || txtEditAuthor.value == "" || selEditCategory.value == "" || txtEditDescription.value == "") {
      alert("Please fill in all fields before submitting the book update.");

      return;
   }

   const updateData = { "id": txtEditBookId.value, "name": txtEditName.value, "author": txtEditAuthor.value, "categoryId": selEditCategory.value, "description": txtEditDescription.value };

   const updateUrl = "https://localhost:44334/api/book/" + txtEditBookId.value + "/update";

   $.ajax({
      type: 'PUT',
      url: updateUrl,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(updateData),
      success: function (data) {
         LoadBooks();
         $("#modalEditForm").modal("hide");

         alert(JSON.stringify(data));

      },
      failure: function (data) {
         alert(data.responseText);
      },
      error: function (data) {
         alert(data.responseText);
      }
   });
}

/**
 * Delete a book using the delete Web API method and reload the table as well
 */
function DeleteBook(id, bookName) {
   var result = confirm("Are you sure you want to delete the book " + bookName + " ?");
   if (!result) {
      return;
   }

   const updateUrl = "https://localhost:44334/api/book/" + id;

   $.ajax({
      type: 'DELETE',
      url: updateUrl,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
         LoadBooks();
      },
      failure: function (data) {
         alert(data.responseText);
      },
      error: function (data) {
         alert(data.responseText);
      }
   });
}