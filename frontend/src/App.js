import './App.css';
import Content from './components/Content/Content';
import Footer from './components/Footer/Footer';
import Header from './components/Header/Header';
import Login from './components/Login/Login';
import {useSelector, useDispatch} from 'react-redux';

function App() {
  const userLoggedIn = useSelector(state => state.userLoggedIn);
  const dispatch = useDispatch();

  function logoutUser(){
    dispatch({type:"LOGGED_OUT"})
  }

  return (
    <div className="App">

      {!userLoggedIn &&
        <div>
          <Login></Login>
        </div>
      }
      
      {userLoggedIn &&
      <div>
        <button onClick={logoutUser}>Log out</button>
        <Header></Header>        
          <Content></Content>
        <Footer></Footer>
      </div>
      }

    </div>
  );
}

export default App;
