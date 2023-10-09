import React, { useEffect, useState } from "react";
import axios from "axios";
import Widgets from "./Widgets";
import { useParams } from "react-router-dom";

function ProductReviews() {
  const [review, setReviews] = useState(null);
  const { id } = useParams();
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(
          "http://localhost:5082/api/Products/" + id
        );
        setReviews(response.data);
      } catch (error) {
        console.error("Error fetching product reviews:", error);
      }
    };

    fetchData();
  }, []);
  console.log(review);
  return (
    <div>
      <h1>Chi tiết sản phẩm</h1>
      <div className="d-flex">
        <img
          style={{ width: "300px", height: "300px" }}
          src={
            review?.photo &&
            require(`/src/assets${review?.photo?.split(",")[0]}`)
          }
          alt="Product Image"
        />
        
      <ul>
        <li key={review?.id}>
          <div>
            <div>Mô tả:{review?.description}</div>
            <div>stock:{review?.stock}</div>
            <div>giá:{review?.price} vnd</div>
            <div>Giá mùa hè:{review?.summary}</div>
          </div>
        </li>
      </ul>
      </div>

    </div>
  );
}

export default ProductReviews;
