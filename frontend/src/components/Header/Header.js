import React from 'react';
import PropTypes from 'prop-types';
import styles from './Header.module.css';
import logo from './../../assets/Platypus-logo.png';

//import logo from './../../assets/Platypus-logo.png';

const Header = () => (
  <div className={styles.Header}>
    <header className="App-header">
      <img src={logo} className="App-logo" alt="logo" />
    </header>
  </div>
);

Header.propTypes = {};

Header.defaultProps = {};

export default Header;
