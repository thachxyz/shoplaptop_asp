import React, { Component } from "react";
import Slider from "react-slick";
import axios from "axios";

class WidgetColumn extends Component {
  constructor(props) {
    super(props);
    this.state = {
      products: [],
    };
  }
  componentDidMount() {
    this.getProducts();
  }
  getProducts() {
    axios
      .get(`http://localhost:5082/api/Products`)
      .then((response) => {
        this.setState({ products: [...response.data] });
      })
      .catch(function (error) {
        console.log(error);
      });
  }
  render() {
    var settings = {
      infinite: true,
      autoplay: true,
      speed: 300,
      dots: true,
      arrows: false,
    };
    return (
      <div>
        <div className="section-title">
          <h4 className="title">{this.props.title}</h4>
          <div className="section-nav">
            <div id="slick-nav-1" className="product-slick-nav"></div>
          </div>
        </div>
        <div className="products-widget-slick" data-nav="#slick-nav-1">
          <Slider {...settings}>
            <div>
              {this.state.products.map((product, index) => (
                <React.Fragment key={"product-widget"}>
                  {index < 3 && (
                    <div className="product-widget">
                      <div className="product-img">
                      <img
                                      src={
                                        product.photo.split(",")[0]
                                          ? require(`../../assets${
                                              product.photo.split(",")[0]
                                            }`)
                                          : ""
                                      }
                                      alt="vuive"
                                    ></img>
                      </div>
                      <div className="product-body">
                        <h3 className="product-name">
                          <a hef="#">{product.title}</a>
                        </h3>
                        {new Date(product.sale_expires).getTime() >
                        new Date().getTime() ? (
                          <h4 className="product-price">
                            {product.price - product.price * product.discount} vnd
                            <del className="product-old-price">
                              {product.price} vnd
                            </del>
                          </h4>
                        ) : (
                          <h4 className="product-price">{product.price} vnd</h4>
                        )}
                        
                      </div>
                    </div>
                  )}
                </React.Fragment>
              ))}
            </div>
            {this.state.products.map((product, index) => (
                <React.Fragment key={"product-widget"}>
                  {(index < 3 && index <6) &&(
                    <div className="product-widget">
                      <div className="product-img">
                      <img
                                      src={
                                        product.photo.split(",")[0]
                                          ? require(`../../assets${
                                              product.photo.split(",")[0]
                                            }`)
                                          : ""
                                      }
                                      alt="vuive"
                                    ></img>
                      </div>
                      <div className="product-body">
                        <h3 className="product-name">
                          <a hef="#">{product.title}</a>
                        </h3>
                        {new Date(product.sale_expires).getTime() >
                        new Date().getTime() ? (
                          <h4 className="product-price">
                            {product.price - product.price * product.discount} vnd
                            <del className="product-old-price">
                              {product.price} vnd
                            </del>
                          </h4>
                        ) : (
                          <h4 className="product-price">{product.price} vnd</h4>
                        )}
                        
                      </div>
                    </div>
                  )}
                </React.Fragment>
              ))}
          </Slider>
        </div>
      </div>
    )
  }
}
class Widgets extends Component{
    constructor(props){
        super(props)
    }
    render()
    {
        return(
            <div className="Section">
                <div className="contrainer">
                    <div className="row">
                        <div className="col-md-4 col-xs-6">
                            <WidgetColumn title="Sản phẩm đang giảm"/>
                        </div>
                        <div className="col-md-4 col-xs-6">
                            <WidgetColumn title="Sản phẩm đang giảm"/>
                        </div>
                        <div className="col-md-4 col-xs-6">
                            <WidgetColumn title="Sản phẩm đang giảm"/>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
export default Widgets;