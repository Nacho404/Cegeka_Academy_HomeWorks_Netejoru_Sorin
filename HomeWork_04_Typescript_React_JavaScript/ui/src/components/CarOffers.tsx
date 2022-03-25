import { useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import { getCars, postOrder } from "../common/api.service";
import { CarModel } from "../models/car.model";
import { OrderModel } from "../models/order.model";
import Car from "./Car";
import CreateBuyCarMenu from "./CreateBuyCarMenu";

//1. Props change
//2. State change

function CarOffers() {
    const [cars, setCars] = useState<CarModel[]>([]);

    useEffect(()=>{
        getCars().then(c => setCars(c));
    },[])


    // functionality for 'CreateOrder Button'
    async function CreateOrder(){
        const customersFromSelect:any = document.getElementById('customersSelect');
        const carOffersFromSelect:any = document.getElementById('carOffersSelect');
        const quantityFromSelect:any = document.getElementById('quantitySelect');
        console.log(customersFromSelect.selectedIndex);
        console.log(carOffersFromSelect.selectedIndex);
        console.log(quantityFromSelect.value);

        const customerId = customersFromSelect.selectedIndex;
        const carOfferId = carOffersFromSelect.selectedIndex;
        const quantity = quantityFromSelect.value;


        const order:OrderModel = {
            customerId,
            carOfferId,
            quantity
        };
        postOrder(order);
        console.log('order created');
    }
    // functionality for 'CreateOrder Button'

    return (
    <div>
        <h2>All cars</h2>
        <div></div>
        <div style={{display:'flex', flexWrap:'wrap'}}>
            {cars.map(c => <div key={c.id}><Car car={c} /></div> )}
        </div>
        <div>
            <Link to='/newcar'><button type="button" className="btn btn-primary" style={{position: 'fixed', bottom: '50px', right:"10px"}}>Add car</button></Link>
        </div>
        
        <div className="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabIndex={-1} aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div className="modal-dialog modal-dialog-centered" style={{width:'auto', height:'auto'}}>
                <div className="modal-content">
                <div className="modal-header">
                    <h5 className="modal-title" id="staticBackdropLabel">Make a Order</h5>
                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div className="modal-body">
                    <CreateBuyCarMenu />
                </div>
                <div className="modal-footer">
                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button id="createOrder" data-bs-dismiss="modal" type="button" className="btn btn-primary" onClick={() =>CreateOrder()}>Create Order</button>
                </div>
                </div>
            </div>
        </div>
        
    </div>);
}



export default CarOffers;