import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getCustomers } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import Customer from "./WirteCustomerInTable";

function Customers() {
    const [customers, setCustomers] = useState<CustomerModel[]>([]);

    useEffect(()=>{
        getCustomers().then(c => setCustomers(c));
    })

    return (
        <div>
            <h2>Customers</h2>
            <div></div>
            <div>
                <table className="table table-dark table-striped">
                    <thead>
                        <tr>
                        <th scope="col">Name</th>
                        <th scope="col">Email</th>
                        </tr>
                    </thead>
                    <tbody>
                    {customers.map(c => <Customer customer={c}/>)}
                    </tbody>
                </table>
            </div>
            <div>
            <Link to='/newcustomer'><button type="button" className="btn btn-primary" style={{position: 'fixed', bottom: '50px', right:"10px"}}>Add customer</button></Link>           </div>
        </div>

    );
}

export default Customers;