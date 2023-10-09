
import './App.css';
import Header from './layouts/Header';
import"./assets/sass/app.scss";
import  Footer  from './layouts/Footer';
import  Main  from './layouts/Main';
import  Nav  from './layouts/Nav';
function App() {
  return (
    <div >
      <Header/>
      <Nav/>
      <Main/>
      <Footer/>
    </div>
  );
}

export default App;
