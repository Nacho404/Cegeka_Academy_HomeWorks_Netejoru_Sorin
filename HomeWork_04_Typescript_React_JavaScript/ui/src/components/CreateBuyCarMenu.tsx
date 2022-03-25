import { randomInt } from "crypto";
import { useEffect, useState } from "react";
import { getCars, getCustomers } from "../common/api.service";
import { CarModel } from "../models/car.model";
import { CustomerModel } from "../models/customer.model";

function CreateBuyCarMenu() {

    const [cars, setCars] = useState<CarModel[]>([]);

    useEffect(()=>{
        getCars().then(c => setCars(c));
    },[])

    const [customers, setCustomers] = useState<CustomerModel[]>([]);

    useEffect(()=>{
        getCustomers().then(c => setCustomers(c));
    },[])

    

    return(
        <div style={{display:'grid', gridGap: '40px'}}>
            <select id='customersSelect' className="form-select" aria-label="Default select example">
                <option defaultValue='Customer Name'>Customer Name</option>
                {customers.map((customer) => {
                    return <option key={customer.id} value={customer.id}>{customer.name}</option>
                } )}
                
            </select>

            <select id='carOffersSelect' className="form-select" aria-label="Default select example">
                <option defaultValue='Car Model'>Car Model</option>
                {cars.map((car) => {
                    return <option key={car.id} value={car.id}>{car.make + ' ' + car.model}</option>
                } )}
            </select>


            <input id='quantitySelect' type="number" className="form-control" placeholder="Quantity" min='1' max='100'/>

        </div>
    )
}

export default CreateBuyCarMenu;
