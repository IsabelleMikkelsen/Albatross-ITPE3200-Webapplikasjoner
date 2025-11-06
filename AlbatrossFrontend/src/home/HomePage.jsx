// Importerer React-biblioteket.
// Selv om det ikke alltid er nødvendig i nyere React-versjoner (17+),
// er det fortsatt vanlig å importere for kompatibilitet og tydelighet
import React from 'react';

// Definerer en funksjonell komponent kalt "HomePage".
// En funksjonell komponent er bare en vanlig JavaScript-funksjon
// som returnerer JSX (HTML-lignende kode som React kan vise i nettleseren).

const HomePage = () => {
    // 'return' forteller hva komponenten skal vise på skjermen.
  // JSX-en under beskriver HTML-strukturen som skal rendres.
  return (
    // <div> er et vanlig HTML-element.
    // className brukes i stedet for "class" fordi "class" er et reservert ord i JavaScript.
    // "text-center" er en Bootstrap-klasse som midtstiller tekst.
    <div className="text-center">
         {/* <h1> er en overskrift (Heading 1). 
          "display-4" er en Bootstrap-klasse som gjør teksten stor og tydelig. */}
      <h1 className="display-4">Welcome to Albatross</h1>
    </div>
  );
};
// Gjør komponenten tilgjengelig for andre filer i prosjektet.
// Når du skriver "import HomePage from './home/HomePage';" i en annen fil,
// er det denne komponenten som importeres.

export default HomePage;
