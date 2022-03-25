import { CarModel } from "../models/car.model";
import { CustomerModel } from "../models/customer.model";
import { OrderModel } from "../models/order.model";

export function getCars(): Promise<CarModel[]> {
    return fetch('https://localhost:7198/CarOffer')
        .then(r => r.json())
}

export function postCar(car: CarModel) {
    fetch('https://localhost:7198/CarOffer/create-carOffer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    })
}

export function getCustomers(): Promise<CustomerModel[]>{
    return fetch('https://localhost:7198/Customer/select-all-customers')
        .then(respons => respons.json())
}


export function postCustomer(customer: CustomerModel){
    fetch('https://localhost:7198/Customer/create-customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
}


export function postOrder(order: OrderModel){
    fetch('https://localhost:7198/Order/create-order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    })
}