fetch('https://localhost:7236/api/Student')
.then(function(response){
    return response.json();
})
.then(function(response){
    displayStudents(response);
})
.catch(err => console.error(err));

var SN = 0;
self = this;
self.studentToDelete;

function displayStudents(response) {
    var studentTable = document.getElementById('StudentTable');
    
    
    


    response.map((student) => {
        // create a new row on the table for each student
        if (student.isActive) {
            let newStudent = ++SN

            let tableRow = document.createElement('tr'); // student
            tableRow.setAttribute('id', `${newStudent}`)

            let tableData1 = document.createElement('td'); // SN
            

            let tableData2 = document.createElement('td'); // firstname
            tableData2.setAttribute('id', `${student.firstName}`);

            let tableData3 = document.createElement('td'); // lastname
            tableData3.setAttribute('id', `${student.lastName}`);


            let tableData4 = document.createElement('td'); // matricNo
            tableData4.setAttribute('id', `${student.matricNo}`);

            let tableData5 = document.createElement('td'); // level
            tableData5.setAttribute('id', `${student.level}`);

            let tableData6 = document.createElement('td'); // department
            tableData6.setAttribute('id', `${student.department}`);

            let tableData7 = document.createElement('td'); // program
            tableData7.setAttribute('id', `${student.program}`)


            let tableData8 = document.createElement('td');
            let tableData9 = document.createElement('td');

            /* creating the table data for each student */
            var studentSN = document.createTextNode(`${newStudent}`);
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
    }
})

        
}


// form handling (POST)



function handleSubmit(event) {
    // stop form submission
    if (event != undefined) {
        event.preventDefault();
        var rawData = new FormData(event.target);
    }
    

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

    
        

        if (self.method){

            if (self.method ==  "PUT"){
                data = {
                    id: self.studentId,
                    firstName : rawData.get('fname'),
                    lastName: rawData.get('lname'),
                    matricNo: rawData.get('matricNo'),
                    level: rawData.get('level'),
                    department: rawData.get('dept'),
                    program: rawData.get('prog')
                };
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
                });
            }

            else if (self.method =="DELETE"){
                // get the data
                fetch('https://localhost:7236/api/Student/' + self.studentId, {
                    method: 'PUT',
                    headers: {
                    'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(self.studentToDelete),
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
    window.location.reload();
}

function revealForm() {
    document.getElementById('popup').style.display = "block";
}

function revealFormAndPost() {
    document.getElementById('popup').style.display="block";
    var form = document.querySelector('form');
    form.addEventListener("submit", handleSubmit);
}

function revealDeleteForm() {
    document.getElementById('popup').style.display = "block";
    document.getElementById('popup__form').style.display = "none";
    
    // add the h3, p, and buttons to the div.popup__content element
     
    // the tags
    let container = document.getElementById('popup__content');
    container.setAttribute('class', 'deleteOperation');

    let minorContainer = document.createElement('div');
    minorContainer.setAttribute('class', 'minor-container');

    let headerTag = document.createElement('h3');

    let paragraphTag = document.createElement('p');
    
    let buttonContainer = document.createElement('div');
    buttonContainer.setAttribute('class', 'decisionBtn');

    let acceptButton = document.createElement('button');
    acceptButton.setAttribute('class', 'edit aBtn'); //styling
    acceptButton.setAttribute('onclick', 'handleDelete()');

    let declineButton = document.createElement('button');
    declineButton.setAttribute('class', 'delete aBtn');
    declineButton.setAttribute('onclick', 'removeForm()');

    // the tag text
    let headerText = document.createTextNode('💀 Danger 💀');
    let paragraphText = document.createTextNode('Are you sure you want to delete the selected student?')
    let acceptButtonText = document.createTextNode('Yes');
    let declineButtonText = document.createTextNode('No');

    // actual task completion
    headerTag.appendChild(headerText);
    minorContainer.appendChild(headerTag);
    container.appendChild(minorContainer);

    paragraphTag.append(paragraphText);
    minorContainer.appendChild(paragraphTag);
    container.appendChild(minorContainer);

    acceptButton.appendChild(acceptButtonText);
    buttonContainer.appendChild(acceptButton);
    minorContainer.appendChild(buttonContainer);
    container.appendChild(minorContainer);

    declineButton.appendChild(declineButtonText);
    buttonContainer.appendChild(declineButton)
    minorContainer.appendChild(buttonContainer);
    container.appendChild(minorContainer);
}


function revealFormAndPut() {
    document.getElementById('popup').style.display="block";
    self.method = "PUT";
    var form = document.querySelector('form');
    form.addEventListener("submit", handleSubmit);
}




let popUpClose = document.getElementById('popup__close');
popUpClose.addEventListener("click", removeFormAndReload);


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

    // get data
    studentToDelete = e.target.parentElement.parentElement;
    console.log(studentToDelete)

    studentToDeleteFirstName = studentToDelete.children[1].id;
    console.log(studentToDeleteFirstName);

    studentToDeleteLastName = studentToDelete.children[2].id;
    console.log(studentToDeleteLastName);

    studentToDeleteMatricNo = studentToDelete.children[3].id;
    console.log(studentToDeleteMatricNo);

    studentToDeleteLevel = studentToDelete.children[4].id;
    console.log(studentToDeleteLevel);

    studentToDeleteDept = studentToDelete.children[5].id;
    console.log(studentToDeleteDept);

    studentToDeleteProg = studentToDelete.children[6].id;
    console.log(studentToDeleteProg);

    self.studentToDelete = {
        id: self.studentId,
        firstName : studentToDeleteFirstName,
        lastName: studentToDeleteLastName,
        matricNo: studentToDeleteMatricNo,
        level: studentToDeleteLevel,
        department: studentToDeleteDept,
        program: studentToDeleteProg,
        isactive: false
    }

    revealDeleteForm() // soft delete
    //self.method = "DELETE"; 
    //handleSubmit()
}

function handleDelete() {
    self.method = "DELETE"; 
    handleSubmit()
}

/* The extra stuff that mr dara added to the code */
function viewInactiveStudents() {
    
    document.getElementById('StudentTable').style.display = "none";
    
  
}

function viewActiveStudents() {
    window.location.reload();
}

