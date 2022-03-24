
function CreateBuyCarMenu() {


    return(
        <div style={{display:'grid', gridGap: '40px'}}>
            <select className="form-select" aria-label="Default select example">
                <option defaultValue='Customer Name'>Customer Name</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
            </select>

            <select className="form-select" aria-label="Default select example">
                <option defaultValue='Car Model'>Car Model</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
            </select>


            <select className="form-select" aria-label="Default select example">
                <option defaultValue='Quantity'>Quantity</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
            </select>
        </div>
    )
}

export default CreateBuyCarMenu;