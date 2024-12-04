async function fetchCharacters() {
  try {
    const result = await fetch('api/characters');

    // throws an error if the server doesn't work
    if (!result.ok) {
      throw new Error('Failed to fetch characters');
    }

    // convert from JSON to Javascript Object
    const characters = await response.json();

    // find the element in html where the data is to be implemented
    const container = document.getElementById('char-container');

    // removes what is already within the html document
    container.innerHTML = '';

    // loops through and creates new boxes for each character, implementing the same variables as those used in the model
    characters.forEach((character) => {
      const box = document.createElement('li');
      box.className = 'box';

      box.innerHTML = `
        <img src="${character.image}" alt="${character.name}" />
        <p class="text"><strong>${character.name}</strong></p>
        <p>${character.about}</p>
        <p><em>Film: ${character.film}, Age: ${character.age}</em></p>
      `;
      //updates the webpage with the new boxes
      container.appendChild(box);
    });
    // if an error occurs, the html is set to an error message
  } catch (error) {
    console.error('Error fetching characters:', error);
    const container = document.getElementById('char-container');
    container.innerHTML = '<p>Failed to load characters</p>';
  }
}

// executes the function
fetchCharacters();

// Connect to the api
//document.getElementById('ghib-container');
//document.addEventListener('click', async () => {
//  const response = await fetch('../api/characters');
//  const data = await response.json();
//  document.getElementById('box').textContent = JSON.stringify(data, null, 2);
//});

//import { url } from './server.js';
//
//// Find elements in HTML document
//const ul = document.querySelector('#char-container');
//
//// Message server
//const response = await fetch(url);
//console.log(response);
//
//// Check that everything works
//async function checkapi(api) {
//  try {
//    BoxCreators();
//  } catch {
//    throw new console.error(api.statusText);
//  }
//}
//
//// Convert from JSON to JavaScript Object
//const data = await response.json();
//console.log(data);
//
//checkapi(response);
//
//// Create the boxes
////function BoxCreators() {
////   for (let i = 0; i < )
////}
