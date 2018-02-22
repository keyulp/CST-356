function displaySummary() {

    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var age = document.getElementById("age").value;

    if (firstName == null || firstName == "") {
        alert("Please Fill In First Name Field");
        return false;
    }
    else if (lastName == null || lastName == "") {
        alert("Please Fill In Last Name Field");
        return false;
    }
    else if (age == null || age == "") {
        alert("Please Fill In Age Field")
    }
    else {

        var summary = firstName + " " + lastName + " is " + age + " years old.";

        document.getElementById("summary").innerText = summary;

        return false;
    }
}