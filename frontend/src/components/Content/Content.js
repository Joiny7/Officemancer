import React, { useState } from 'react';
import styles from './Content.module.css';
import axios from 'axios';
import Moment from 'moment'; 


const Content = () => {
  const [showMonth, setShowMonth] = useState('');
  const [showDay, setShowDay] = useState([]);

  axios.post('api/User/GetMonth?officeID=1&month=11&year=2020',{}).then(response => {
    setShowDay(response.data.days);
    setShowMonth(response.data.month);
    //console.log(response.data);
  }); 

  Moment.locale('sv');

  return (
    <div className={styles.Content}>
      <div className="ui grid">
        <div className="ui center aligned header icon">
          <h1 className="center">{showMonth}</h1>
        </div>
        <div className="five column row">
        <div className="column">mån</div>
        <div className="column">tis</div>
        <div className="column">ons</div>
        <div className="column">tor</div>
        <div className="column">fre</div>
      </div>  
      <div className="five column row cards">
          {showDay.map((item, i) => {
            return (
                <div className={`ui column card ${styles.Contentcal}`} key={item.date}>
                  <h3>{Moment(item.date).format('D')}</h3>
                  <div>Upptagna platser: { item.currentCapacity }</div>
                </div>
            )  
            
          })}
        </div>
      </div>
      
    </div>
  );
};



export default Content;
