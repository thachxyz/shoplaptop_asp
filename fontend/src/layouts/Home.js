import React from "react";
import Collections from "../pages/home/Collection";
import Carousel from "../pages/home/Carousel";
import HotDeals from "../pages/home/HotDeals";
import Widgets from "../pages/home/Widgets";


function Home(props) {
  return (
    <div>
      <Collections />
      <Carousel title="Sản Phẩm mới " id="1"/>
      <HotDeals/>
      <Widgets/>
      
    </div>
  );
}
export default Home;