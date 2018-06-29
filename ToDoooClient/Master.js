"option strict"

function create(){
    var User = {
        Id:0,
        UserName: document.getElementById("fUserName").value,
        Password: document.getElementById("fPassword").value,
        FirstName: document.getElementById("fFirstName").value,
        LastName: document.getElementById("fLastName").value,
        Email: document.getElementById("fEmail").value,
        IsAdmin : false,
        IsActive: true,
        IsReviewer: false

    }

    $.post("http://localhost:58587/Users/Create" , User)
        .done(function(Resp){
            console.log(Resp)
            alert("New User Created!")
        });

}