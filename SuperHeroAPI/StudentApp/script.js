
fetch('https://localhost:7236/api/Student')
.then(function(response){
    return response.json();
})
.then(function(response){
    console.log(response);
    displayStudents(response);
})
.catch(err => console.error(err));

var SN = 0;

function displayStudents(response) {
    var studentTable = document.getElementById('StudentTable');
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
    
    


    response.map((student) => {
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
        editButton.appendChild(editButtonText);

        /* delete button */
        var deleteButtonText = document.createTextNode("Delete");
        let deleteButton = document.createElement('button');
        deleteButton.className = "delete";
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