import { CustomerModel } from "../models/customer.model";

interface TProps {
    customer: CustomerModel
}


function Customer(props: TProps){
    return (
        <>
            <td>{props.customer.name}</td>
            <td>{props.customer.email}</td>
        </>
    )
}

export default Customer;