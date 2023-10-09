import React, { useState, useRef, useEffect} from 'react';
import  Axios  from 'axios'

const HotDeals = () => {
    const [endDate, setEndDate] = useState('');
    const [timerDays, setTimerDays] = useState('00');
    const [timerHours, setTimerHours] = useState('00');
    const [timerMinutes, setTimerMinutes] = useState('00');
    const [timerSeconds, setTimerSeconds] = useState('00');

    let interval = useRef ();

    const startTimer = () => {
        const countDownDate = new Date(endDate).getTime();

        interval = setInterval(() => {
            const now = new Date().getTime();
            const distance = countDownDate - now;
            const days = Math.floor(distance / (1000 * 60 * 60 * 24));
            const hours = Math.floor(distance % (1000 * 60 * 60 * 24) / (1000 * 60 * 60));
            const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            const seconds = Math.floor(distance % ((1000 * 60)) / 1000);
            if (distance<0){
                //stop
                clearInterval(interval.current);
            }else {
                //update
                setTimerDays(days);
                setTimerHours(hours);
                setTimerMinutes(minutes);
                setTimerSeconds(seconds);
            }
        }, 1000);
    }
    useEffect(() =>{
        if (!endDate) {
            Axios.get('http://localhost:5082/api/Deal').then(result =>{
                setEndDate(result.data.ends)
            }).catch(error => {
                console.log(error)
            })
        }
        if(endDate) {
            startTimer();
            return ()=> {
                clearInterval(interval.current);
            }
        }
    })
    return (
        <div id="hot-deal" className="section">
            <div className="container">
                <div className="row">
                    <div className="col-md-12">
                        <div className="hot-deal">
                            <ul className="hot-deal-countdown">
                                <li>
                                    <div>
                                        <h3>{timerDays}</h3>
                                        <span>Ngày</span>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <h3>{timerHours}</h3>
                                        <span>Giờ</span>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <h3>{timerMinutes}</h3>
                                        <span>Phút</span>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                    <h3>{timerSeconds}</h3>
                                        <span>Giay</span>
                                    </div>
                                </li>
                            </ul>
                            <h2 className="text-uppercase">Khuyến mãi hấp dẫn tuần này</h2>
                            <p>Sản phẩm mới giảm giá 50%</p>
                            <a className="primary-btn cta-btn" href="#">Mua ngay </a>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    )
}
export default HotDeals