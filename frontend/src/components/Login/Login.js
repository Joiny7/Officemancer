import React from 'react';
import styles from './Login.module.css';
import {useSelector, useDispatch} from 'react-redux';

function Login() {
  const userLoggedIn = useSelector(state => state.userLoggedIn);
  const dispatch = useDispatch();

  function loginUser(){
    dispatch({type:"LOGGED_IN"})
    console.log(userLoggedIn);
   }
      
  return (
    <div className={styles.Login}>
      <h2>User is logged out</h2>
      <button onClick={loginUser}>Log in</button>
    </div>
  );
}

export default Login;
