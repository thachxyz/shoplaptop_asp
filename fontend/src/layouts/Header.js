import React,{Component} from "react";
import { Link } from "react-router-dom";
class Header extends Component{
    constructor(props){
        super(props)
    }
    render(){
        return(
            <header>
                {/* TOP HEADER */}
                <div id="top-header">
                    <div className="container">
                        <ul className="header-links">
                            <li><a href="#"><i className="fa fa-phone"></i>+84-767678479</a></li>
                            <li><a href="#"><i className="fa fa-envelope-o"></i> info@hangdinhtam.com</a></li>
                            <li><a href="#"><i className="fa fa-map-marker"></i> 20 Tăng Nhơn Phú</a></li>

                        </ul>
                        <ul className="header-links">
                            <li><a href="#"><i className="fa fa-vnd"></i>VND</a></li>

                        </ul>
                    </div>
                </div>
                {/* END TOP HEADER */}

                {/* MAIN HEADER */}
                <div id="header">
                    <div className="container">
                        <div className="row">
                            <div className="col-md-3">
                                <div className="header-logo">
                                    <Link to={"/"} className="logo">
                                        <img src={require ('../assets/images/logo4.png')} alt="logo"/>
                                    </Link>
                                </div>
                            </div>
                            {/* LOGO */}
                            {/* SEARCH */}
                            <div className="col-md-6">
                                <div className="header-search">
                                    <form>
                                        <select className="input-select">
                                            <option value={0}> Tất cả sản phẩm</option>
                                            <option value={1}> Laptop</option>
                                            <option value={1}> Điện thoại</option>
                                            <option value={1}> Máy tính bảng</option>
                                            <option value={1}> Phụ kiện</option>
                                        </select>
                                        <input className="input" placeholder="Tìm kiếm tại đây"/>
                                        <button className="search-btn">Search</button>
                                    </form>
                                </div>
                            </div>
                            {/* ACCOUNT */}
                            <div className="col-md-3">
                                <div className="header-ctn">
                                    {/* WishList */}
                                    <div>
                                        <Link to="/wishList">
<i className="fa fa-heart-o"></i>
                                            <span>Yêu thích</span>
                                            <div className="qty">2</div>
                                        </Link>
                                    </div>
                                    {/* End wishList */}

                                    {/* Cart */}
                                    <div className="dropdown">
                                        <Link className="dropdown-toggle" to={'/shopping-cart'}>
                                            <i className="fa fa-shopping-cart"></i>
                                            <span>Giỏ hàng</span>
                                            <div className="qty">5</div>
                                        </Link>
                                    </div>
                                    {/* End Cart */}
                                    {/* Menu Toggle */}
                                    <div className="menu-toggle">
                                        <a href="#">
                                            <i className="fa fa-bars"></i>
                                            <span>Menu</span>
                                        </a>
                                    </div>
                                    {/* End Menu */}

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </header>
        )
    }
    
}
export default Header