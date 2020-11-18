import logo from './assets/Platypus-logo.png';
import './App.css';
import Content from './components/Content/Content';
import Footer from './components/Footer/Footer';
import {useSelector, useDispatch} from 'react-redux';

function App() {
  const userLoggedIn = useSelector(state => state.userLoggedIn);
  const dispatch = useDispatch();

  function loginUser(){
    dispatch({type:"LOGGED_IN"})
  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
              
        {userLoggedIn &&
          <h2>User is logged in</h2>
        }
       <button onClick={loginUser}>Log in</button>

       </header>
      <Content></Content>
      <Footer>
      </Footer>
    </div>
  );
}

export default App;
