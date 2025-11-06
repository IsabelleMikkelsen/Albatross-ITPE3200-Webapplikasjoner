import React from 'react';
import { Table } from 'react-bootstrap';

const ItemListPage= () => {
    const item = [
        {
            ItemId :1, 
            Name: "Dress",
            Description: "A beautiful summer dress perfect for a trip to Tirana",
            Price: 799,
            ImageUrl: "/images/dress.jpg",

        },
        {
            ItemId :2,
            Name: "Sunglasses",
            Description: "Stylish sunglasses to protect your eyes from the sun",
            Price: 199,
            ImageUrl: "/images/sunglasses.jpg",
        },


    ];

    return (
        <div>
            <h1>Item List</h1>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Price</th>
                        <th>Images</th>
                    </tr>
                </thead>
                <tbody>
                    {item.map((item) => (
                        <tr key={item. ItemId}>
                            <td>{item.ItemId}</td>
                            <td>{item.Name}</td>
                            <td>{item.Description}</td>
                            <td>{item.Price} XP</td>
                            <td>
                                <img src={item.ImageUrl} alt={item.Name} width="120" />
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    );

   
};
export default ItemListPage;