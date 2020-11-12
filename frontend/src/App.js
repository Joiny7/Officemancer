import logo from './assets/Platypus-logo.png';
import './App.css';
import Content from './components/Content/Content'


function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
      </header>
      <Content></Content>
      <footer>
        <hr />
        <p>Om Platypus</p>
        <p>Skicka feedback</p>
      </footer>
    </div>
  );
}

export default App;
