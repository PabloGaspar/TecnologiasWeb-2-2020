window.addEventListener('load', (event) => {
    
    
    
    
    
    
    fetch('http://localhost:57891/api/values')
    .then((response) => {
        debugger; 
        return response.json()})
    .then((data) =>{
        debugger;
        console.log(JSON.stringify(data))
    } );
    
    /*let person = [];
    console.log('page is fully loaded');

    async function  fetchData(){
        const response  = await fetch('http://localhost:57891/api/values');
    
        console.log( response);
        if(response.status === 200){
            const data = await response.json();
            console.log(data);
             let stringArray = data.map((person) => `<li> ${`${person.age}  |   ${person.name}` }</li>`);
             let stringJoin = stringArray.join('');
             let responseList = `<ul> ${ stringJoin } </ul>`
            document.getElementById("response-content").innerHTML = responseList;
        } else{
            console.log(response);
        }
  };

  function submitPerson (event){
    event.preventDefault();
    console.log(event.currentTarget.elements.name.value);
    const personToSent = {
        "name" : event.currentTarget.elements.name.value,
        "age" :parseInt(event.currentTarget.elements.age.value) 

    }

    fetch('http://localhost:57891/api/values', {
    headers: { "Content-Type": "application/json; charset=utf-8" },
    method: 'POST',
    body: JSON.stringify(personToSent)
    }).then( (response) =>{
        console.log(response);
        return response.json();
    })
    .then(data => {
        console.log(data);
    })

  }

  document.getElementById("fetchBtn").addEventListener("click",fetchData);
  document.getElementById("personFrm").addEventListener("submit", submitPerson)*/
});




//     function fetchData(){
//         fetch('http://localhost:57891/api/values')
//         .then(function(response){
//             console.log( response);
//             if(response.status === 200){
//                 return response.json();
//             } else{
//                 console.log(response);
//             }
            
//         })
//         .catch(error => console.error('Error:', error))
//         .then((data) =>{
//             console.log(data);
//         } )
//     }
//     document.getElementById('fetchBtn').addEventListener('click', fetchData);
//   });
 

// //https://www.freecodecamp.org/news/a-practical-es6-guide-on-how-to-perform-http-requests-using-the-fetch-api-594c3d91a547/
// //document.querySelector("input[type=button]").addEventListener("click", fetchData);
// document.getElementById("fetchbtn").addEventListener("click", fetchData);
// document.getElementById("postbtn").addEventListener("click", postData);
// document.getElementById("myForm").addEventListener("submit", postData);

// function fetchData(){
//     fetch('http://localhost:57891/api/values')
//     .then((res) => {
//         console.log('res:', res);
//         return res.json()})
//     .catch(error => console.error('Error:', error))
//     .then((json) => {
//         console.log('Success:', json)
        
//         document.querySelector('body .container').innerHTML = '<ul>' + json.map(function (element) {
//             return '<li>' + element + '</li>';
//         }).join('') + '</ul>'
//     });
// }

// async function fetchDataAsync(){
//     try {
//         const response = await fetch('http://localhost:57891/api/values');
//         const json = await response.json();
//         document.querySelector('body .container').innerHTML = '<ul>' + json.map(function (element) {
//             return '<li>' + element + '</li>';
//         }).join('') + '</ul>'
//     } catch (error) {
//         console.log(error);
//     }
    
    
// }

// function postData (event){
//     console.log('event target', event.target.elements.name.value);
//     event.preventDefault();
//     var url = 'http://localhost:57891/api/values';
//     //var data = {username: 'example'};
//     var data = 'example';
//     fetch(url, {
//     method: 'POST', // or 'PUT'
//     body: JSON.stringify(data), // data can be `string` or {object}!
//     headers:{
//         'Content-Type': 'application/json'
//     }
//     }).then((res) => {
//         return res.json()})
//     .catch(error => console.error('Error:', error))
//     .then((response) => {
//         console.log('Success:', response)
//     });
// }

