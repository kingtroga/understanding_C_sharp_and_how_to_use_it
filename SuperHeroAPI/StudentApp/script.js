
fetch('https://localhost:7236/api/Student')
.then(function(response){
    return response.json();
})
.then(function(response){
    displayStudents(response);
})
.catch(err => console.error(err));

var SN = 0;

function displayStudents(response) {
    var studentTable = document.getElementById('StudentTable');
    
    
    


    response.map((student) => {
        // create a new row on the table for each student
        let tableRow = document.createElement('tr');
        let tableData1 = document.createElement('td');
        let tableData2 = document.createElement('td');
        let tableData3 = document.createElement('td');
        let tableData4 = document.createElement('td');
        let tableData5 = document.createElement('td');
        let tableData6 = document.createElement('td');
        let tableData7 = document.createElement('td');
        let tableData8 = document.createElement('td');
        let tableData9 = document.createElement('td');

        /* creating the table data for each student */
        var studentSN = document.createTextNode(`${++SN}`);
        var studentFirstName = document.createTextNode(`${student.firstName}`);
        var studentLastName = document.createTextNode(`${student.lastName}`);
        var studentMatricNo = document.createTextNode(`${student.matricNo}`);
        var studentLevel = document.createTextNode(`${student.level}`);
        var studentDepartment = document.createTextNode(`${student.department}`);
        var studentProgram = document.createTextNode(`${student.program}`);

        /* edit button */
        var editButtonText = document.createTextNode("Edit");
        let editButton = document.createElement('button');
        editButton.className = "edit";
        editButton.setAttribute("onclick", "handleClickPUT(event)");
        editButton.setAttribute("id", `${student.id}`)
        editButton.appendChild(editButtonText);

        /* delete button */
        var deleteButtonText = document.createTextNode("Delete");
        let deleteButton = document.createElement('button');
        deleteButton.className = "delete";
        deleteButton.setAttribute("onclick", "handleClickDelete(event)");
        deleteButton.setAttribute("id", `${student.id}`)
        deleteButton.appendChild(deleteButtonText);

        tableData1.appendChild(studentSN);
        tableRow.appendChild(tableData1);

        tableData2.appendChild(studentFirstName);
        tableRow.appendChild(tableData2);

        tableData3.appendChild(studentLastName);
        tableRow.appendChild(tableData3);

        tableData4.appendChild(studentMatricNo);
        tableRow.appendChild(tableData4);

        tableData5.appendChild(studentLevel);
        tableRow.appendChild(tableData5);

        tableData6.appendChild(studentDepartment);
        tableRow.appendChild(tableData6);

        tableData7.appendChild(studentProgram);
        tableRow.appendChild(tableData7);

        tableData8.appendChild(editButton);
        tableRow.appendChild(tableData8);

        tableData9.appendChild(deleteButton);
        tableRow.appendChild(tableData9);

        studentTable.appendChild(tableRow);   
    })
}


// form handling (POST)



function handleSubmit(event) {
    // stop form submission
    event.preventDefault();

    console.log(self.studentId);
    console.log(self.method);

    var rawData = new FormData(event.target);

    if (self.studentId == undefined) {
        let data = {
            firstName : rawData.get('fname'),
            lastName: rawData.get('lname'),
            matricNo: rawData.get('matricNo'),
            level: rawData.get('level'),
            department: rawData.get('dept'),
            program: rawData.get('prog')
        }
    
        // add a new student
        fetch('https://localhost:7236/api/Student', {
            method: 'POST',
            headers: {
            'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
        .then((data) => {
        console.log('Success:', data);
        removeFormAndReload();
        })
        .catch((error) => {
        console.error('Error:', error);
        removeFormAndReload();
        window.alert(error);
        });
    }

    
        data = {
            id: self.studentId,
            firstName : rawData.get('fname'),
            lastName: rawData.get('lname'),
            matricNo: rawData.get('matricNo'),
            level: rawData.get('level'),
            department: rawData.get('dept'),
            program: rawData.get('prog')
        }

        if (self.method){
            if (self.method ==  "PUT"){
                fetch('https://localhost:7236/api/Student/' + self.studentId, {
                method: 'PUT',
                headers: {
                'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
                })
                .then((data) => {
                console.log('Success:', data);
                removeFormAndReload();
                })
                .catch((error) => {
                console.error('Error:', error);
                removeFormAndReload();
                window.alert(error);
                });}
            else if (self.method =="DELETE"){
                fetch(`https://localhost:7236/api/Student/${self.studentId}`, {
                method: 'DELETE',
                headers: {
                'Content-Type': 'application/json',
                }
                })
                .then(window.location.reload());
            }   
            else {
                window.alert("What the fuck did you do?");
            }
        }

    
    
    
}

function removeFormAndReload() {
    // remove the form from the user's view
    document.getElementById('popup').style.display = "none";

    // reload the page for the user to see the new student added
    window.location.reload();
    
}

function removeForm() {
    document.getElementById('popup').style.display = "none";
}

function revealForm() {
    document.getElementById('popup').style.display = "block";
}

function revealFormAndPost() {
    document.getElementById('popup').style.display="block";
    var form = document.querySelector('form');
    form.addEventListener("submit", handleSubmit);
}


function revealFormAndPut() {
    document.getElementById('popup').style.display="block";
    self.method = "PUT";
    var form = document.querySelector('form');
    form.addEventListener("submit", handleSubmit);
}

function revealFormAndDelete() {
    //document.getElementById('popup').style.display="block";
    self.method = "DELETE";
    var form = document.querySelector('form');
    form.addEventListener("submit", handleSubmit);
}



let popUpClose = document.getElementById('popup__close');
popUpClose.addEventListener("click", removeFormAndReload);

self = this;
self.studentId;
function handleClickPUT(e) {
    var studentId = `${e.target.id}`;
    self.studentId = String(studentId);
    //console.log(self.studentId);
    revealFormAndPut();
}


function handleClickDelete(e) {
    var studentId = `${e.target.id}`;
    self.studentId = String(studentId);
    console.log(self.studentId);
    revealFormAndDelete();
}



