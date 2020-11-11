import React, { useState } from 'react';
import styles from './Content.module.css';
import axios from 'axios';



const Content = () => {
  const [showMonth, setShowMonth] = useState([]);
  axios.post('api/User/GetMonth?officeID=1&month=11&year=2020',{}).then(response => {
    setShowMonth(response.data.days);
    console.log(response.data.days);
  }); 

  return (
    <div className={styles.Content}>
      {showMonth.map((item, i) => {
        return  <li key={item}>{item.date}</li>
      })}
    </div>
  );
};



export default Content;
