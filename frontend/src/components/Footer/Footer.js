import React from 'react';
import PropTypes from 'prop-types';
import styles from './Footer.module.css';

const Footer = () => (
  <div className={styles.Footer}>
        <p>Om Platypus</p>
        <p>Skicka feedback</p>
  </div>
);

Footer.propTypes = {};

Footer.defaultProps = {};

export default Footer;
