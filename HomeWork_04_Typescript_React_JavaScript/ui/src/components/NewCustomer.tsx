import { useState } from "react";
import { Link } from "react-router-dom";
import { postCustomer } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";

function NewCustomer(){
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');

    function handleClick(){
        const newCustomer:CustomerModel = {
            name,
            email
        };
        postCustomer(newCustomer);
    }

    return (
        <>
            <h2>New Car</h2>
            <div>
                <div className="mb-3">
                    <label className="form-label">Name</label>
                    <input type="text" className="form-control" placeholder="Name" onChange={ev => setName(ev.target.value)} />
                </div>
                <div className="mb-3">
                    <label className="form-label">Email</label>
                    <input type="text" className="form-control" placeholder="Email" onChange={ev => setEmail(ev.target.value)}/>
                </div>
                <a href='/customers' className="btn btn-primary" onClick={() => handleClick()}>Save</a>
            </div>
        </>
    )
}

export default NewCustomer;