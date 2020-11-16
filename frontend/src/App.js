import logo from './assets/Platypus-logo.png';
import './App.css';
import Content from './components/Content/Content';
import Footer from './components/Footer/Footer';


function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
      </header>
      <Content></Content>
      <Footer>
      </Footer>
    </div>
  );
}

export default App;
