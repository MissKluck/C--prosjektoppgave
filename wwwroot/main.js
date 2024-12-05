//waits until the html is fully loaded before executing the function
document.addEventListener('DOMContentLoaded', (async) => {
  async function fetchCharacters() {
    try {
      const result = await fetch('api/characters');

      // throws an error if the server doesn't work
      if (!result.ok) {
        throw new Error('Failed to fetch characters');
      }

      // convert from JSON to Javascript Object
      const characters = await result.json();

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
});
