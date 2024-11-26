// Connect to the api
import { url } from './server.js';

// Find elements in HTML document
const ul = document.querySelector('#char-container');

// Message server
const response = await fetch(url);
console.log(response);

// Check that everything works
async function checkapi(api) {
  try {
    BoxCreators();
  } catch {
    throw new console.error(api.statusText);
  }
}

// Convert from JSON to JavaScript Object
const dta = await response.json();
console.log(data);

checkapi(response);

// Create the boxes
//function BoxCreators() {
//   for (let i = 0; i < )
//}
