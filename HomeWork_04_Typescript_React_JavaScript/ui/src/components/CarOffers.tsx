import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getCars } from "../common/api.service";
import { CarModel } from "../models/car.model";
import Car from "./Car";

//1. Props change
//2. State change

function CarOffers() {
    const [cars, setCars] = useState<CarModel[]>([]);

    useEffect(()=>{
        getCars().then(c => setCars(c));
    },[])

    return (
    <div>
        <h2>All cars</h2>
        <div></div>
        <div style={{display:'flex', flexWrap:'wrap'}}>
            {cars.map(c => <Car car={c} />)}
        </div>
        <div>
            <Link to='/newcar'><button type="button" className="btn btn-primary" style={{position: 'fixed', bottom: '50px', right:"10px"}}>Add car</button></Link>
        </div>
    </div>);
}

export default CarOffers;