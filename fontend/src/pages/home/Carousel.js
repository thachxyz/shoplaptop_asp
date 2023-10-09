import React, { Component } from "react";
import axios from "axios";
import Slider from "react-slick";
import Spinner from "react-bootstrap/Spinner";
import Button from "react-bootstrap/Button";

import { Routes, Route, Link } from "react-router-dom";

class Carousel extends Component {
  constructor(props) {
    super(props);
    this.state = {
      loading: true,
      currentCategory: 1,
      categories: [],
      products: [],
    };
    this.handleClick = this.handleClick.bind(this);
  }
  componentDidMount() {
    this.getCategories();
    this.getProducts(1);
  }
  getCategories() {
    axios
      .get("http://localhost:5082/api/Category")
      .then((response) => {
        this.setState({
          categories: [...response.data],
        });
      })
      .catch(function (error) {
        console.log(error);
      });
  }
  getProducts(categoryId) {
    var query;
    if (this.props.id === 1) query = "new";
    else query = "top-selling";

    this.setState({ loading: true });

    axios
      .get("http://localhost:5082/api/Products")
      .then((response) => {
        this.setState({
          products: [...response.data],
          loading: false,
        });
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  handleClick(e) {
    const id = e.target.id;
    if (e.target.className == "add-to-cart-btn") {
      this.props.ShowQuickView(id);
    } else if (
      e.target.className == "quick-view q q-primary" ||
      e.target.className == "fa fa-eye"
    ) {
      this.props.ShowQuickView(id);
    } else {
      e.preventDefault();
      this.getProducts(id);
      this.setState({ currentCategory: id });
    }
  }

  render() {
    var settings = {
      slidesToshow: 3,
      slidesToScroll: 1,
      autoplay: true,
      infinity: true,
      dots: false,
      arrows: true,
      responsive: [
        {
          breakpoint:1980,
          settings: {
            slidesToShow: 3,
            slidesToSrcoll: 1,
          },
        },
        {
          breakponit: 480,
          settings: {
            slidesToshow: 1,
            slidesToScroll: 1,
          },
        },
      ],
    };

    {
      /*<!-- Products tab & slick --> */
    }
    // eslint-disable-next-line no-lone-blocks

    return (
      <div>
        <div className="section">
          {/* <!-- CONTAINER --> */}
          <div className="container">
            {/* <!-- ROW --> */}
            <div className="row">
              {/* <!-- SECTION TITLE --> */}
              <div className="col-md-12">
                <div className="section-title">
                  <h3 className="title">{this.props.title}</h3>
                  <div className="section-nav">
                    <ul className="section-tab-nav tab-nav">
                      {this.state.categories.map((category) => (
                        <li
                          key={category.id}
                          className={
                            category.id == this.state.currentCategory
                              ? "active"
                              : ""
                          }
                        >
                          <a
                            className="text-decoration-none"
                            id={category.id}
                            onClick={this.handleClick}
                            data-toggle="tab"
                            href=""
                          >
                            {category.title}
                          </a>
                        </li>
                      ))}
                    </ul>
                  </div>
                </div>
              </div>
              {/* <!-- /SECTION TITLE --> */}

              {/* <!-- Products tab & slick --> */}
              {this.state.loading ? (
                <div className="spinner-container">
                  <Spinner animation="border" />
                </div>
              ) : (
                <div id="product-container" className="col-md-12">
                  <div className="row">
                    <div className="products-tabs">
                      {/* <!-- TAB --> */}
                      <div
                        id={"tab" + this.props.id}
                        className="tab-pane active"
                      >
                        <div
                          className="products-slick"
                          data-nav={"#slick-nav-" + this.props.id}
                        >
                          <Slider {...settings}>
                            {this.state.products.length > 1 &&
                              this.state.products.map((product) => (
                                <div key={product.id} className="product">
                                  <Link to={"/products/"+ product.id}> 
                                  <div className="product-img" >
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

                                    <div className="product-label">
                                      {/* {(new Date(product.sale_expires).getTime() > new Date().getTime()) && <span className="sale">-{product.sale * 100}%</span>} */}
                                      {new Date(
                                        product.created_at
                                      ).toDateString() ==
                                        new Date().toDateString() && (
                                        <span className="new">NEW</span>
                                      )}
                                    </div>
                                  </div>
                                  <div className="product-body">
                                    {/* <p className="product-category">{product.cat.title}</p> */}
                                    <h3 className="product-name">
                                      <a href="#">{product.title}</a>
                                    </h3>
                                    {new Date(product.sale_expires).getTime() >
                                    new Date().getTime() ? (
                                      <h4 className="product-price">
                                        {product.price -
                                          product.price * product.sale}{" "}
                                        <del className="product-old-price">
                                         {product.price} vnd
                                        </del>
                                      </h4>
                                    ) : (
                                      <h4 className="product-price">
                                       {product.price} vnd
                                      </h4>
                                    )}
                                    <div className="product-rating">
                                      <i
                                        className={
                                          product.review >= 1
                                            ? "fa fa-star"
                                            : product.review > 0 &&
                                              product.review < 1
                                            ? "fa fa-star-half-o"
                                            : "fa fa-star-o"
                                        }
                                      ></i>
                                      <i
                                        className={
                                          product.review >= 2
                                            ? "fa fa-star"
                                            : product.review > 1 &&
                                              product.review < 2
                                            ? "fa fa-star-half-o"
                                            : "fa fa-star-o"
                                        }
                                      ></i>
                                      <i
                                        className={
                                          product.review >= 3
                                            ? "fa fa-star"
                                            : product.review > 2 &&
                                              product.review < 3
                                            ? "fa fa-star-half-o"
                                            : "fa fa-star-o"
                                        }
                                      ></i>
                                      <i
                                        className={
                                          product.review >= 4
                                            ? "fa fa-star"
                                            : product.review > 3 &&
                                              product.review < 4
                                            ? "fa fa-star-half-o"
                                            : "fa fa-star-o"
                                        }
                                      ></i>
                                      <i
                                        className={
                                          product.review >= 5
                                            ? "fa fa-star"
                                            : product.review > 4 &&
                                              product.review < 5
                                            ? "fa fa-star-half-o"
                                            : "fa fa-star-o"
                                        }
                                      ></i>
                                    </div>
                                    <div className="product-btns">
                                      <button className="add-to-compare">
                                        <i className="fa fa-exchange"></i>
                                        <span className="tooltip">
                                          add to compare
                                        </span>
                                      </button>
                                      <Button
                                        id={product.id}
                                        className="quick-view"
                                        onClick={this.handleClick}
                                        bsPrefix="q"
                                      >
                                        <i
                                          id={product.id}
                                          onClick={this.handleClick}
                                          className="fa fa-eye"
                                        ></i>
                                        <span className="tooltip">
                                          quick view
                                        </span>
                                      </Button>
                                    </div>
                                  </div>
                                  <div className="add-to-cart">
                                    <button
                                      id={product.id}
                                      className="add-to-cart-btn"
                                      onClick={this.handleClick}
                                    >
                                      <i
                                        id={product.id}
                                        onClick={this.handleClick}
                                        className="fa fa-shopping-cart"
                                      ></i>{" "}
                                      add to cart
                                    </button>
                                  </div>
                                  </Link>
                                </div>
                              ))}
                          </Slider>
                        </div>
                        <div
                          id={"slick-nav-" + this.props.id}
                          className="products-slick-nav"
                        ></div>
                      </div>
                      {/* <!-- /TAB --> */}
                    </div>
                  </div>
                </div>
              )}
              {/* <!-- /Products tab & slick --> */}
            </div>
            {/* <!-- /ROW --> */}
          </div>
          {/* <!-- /CONTAINER --> */}
        </div>
      </div>
    );
  }
}
export default Carousel;
