debugger
fetch('https://localhost:7236/api/Student', { mode: 'no-cors'})
.then(function(response){
    return response.json();
    
})
.then(function(response){
    console.log(response);
    displayStudents(response);
})



function displayStudents(response) {
    document.getElementById("Loading").innerHTML = "none";
    var studentTable = document.getElementById('StudentTable');
    let tableRow = document.createElement('tr');
    let tableData1 = document.createElement('td');
    let tableData2 = document.createElement('td');
    let tableData3 = document.createElement('td');
    let tableData4 = document.createElement('td');
    let tableData5 = document.createElement('td');
    let tableData6 = document.createElement('td');
    let tableData7 = document.createElement('td');

    response.map((student) => {
        var studentSN = document.createTextNode(`${student.id}`);
        var studentFirstName = document.createTextNode(`${student.firstName}`);
        var studentLastName = document.createTextNode(`${student.lastName}`);
        var studentMatricNo = document.createTextNode(`${student.matricNo}`);
        var studentLevel = document.createTextNode(`${student.level}`);
        var studentDepartment = document.createTextNode(`${student.department}`);
        var studentProgram = document.createTextNode(`${student.program}`);

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

        studentTable.appendChild(tableRow);   
    })
}