import React from "react";
import { Routes, Route, Link } from "react-router-dom";
import Home from "./Home";
import ProductReviews from "../pages/home/ProductReviews";
const Main = () => (
  <main>
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/products/:id" element={<ProductReviews />}/ > 
    </Routes>
  </main>
);
export default Main