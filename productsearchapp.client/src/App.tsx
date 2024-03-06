import './App.css';
import { Button, Container, Grid, Input, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography } from '@mui/material';
import  { ItemDetails }  from './api/types/Entities';
import { useEffect, useState } from 'react';
import React from 'react';




function App() {
    const [itemData, setItems] = useState<ItemDetails>();
    const [itemList, setList] = useState<ItemDetails[]>();
    const [searchText, setSearch] = useState("");
    const [quantityCounter, setQuantity] = useState(0);


    // useEffect(() => {

    //     let item : ItemDetails;
    //     item = itemData;
    //     item.quantity = quantityCounter;
    //     setItems(item)

    // }, [quantityCounter])

    function handleQuantity(quantity: any)
    {
        setQuantity(quantity);
    }
    function deleteItem(rowNumber: number)
    {
        itemList?.filter(i => i.id !== rowNumber);
        console.log({itemList})
        setList(itemList);
        
    }
    function addToCart()
    {
        console.log("add to cart");
        if(itemData != null)
        {
            let item : ItemDetails;
            item = itemData;
            item.quantity = quantityCounter;
            setItems(item)
            console.log({itemList});
            let tempList : ItemDetails[] = [];
            tempList.push(itemData);
            setList(tempList);
            console.log({tempList});
        }
        
    }
    function getItem()
    {
        if(searchText.length > 0)
        {
            console.log({searchText});
            searchItem();
        }
    }
    async function searchItem() {

        const response = await fetch(`products/${searchText}`);
        const data = await response.json();
        setItems(data); 
        
        
    }
    console.log({itemData});
    
    return (
        <>
            <Container>
            <Grid>
    <Typography>Search</Typography>
    <TextField onChange={(event) => {setSearch(event.target.value)}}></TextField>
    <Button onClick={() => {getItem()}}>Go</Button>
</Grid>
<Grid>
    <Typography>ID</Typography>
    <TextField value={itemData?.id}></TextField>
</Grid>
<Grid>
    <Typography>Name</Typography>
    <TextField value={itemData?.name}></TextField>
</Grid>
<Grid>
    <Typography>Cost</Typography>
    <TextField  value={itemData?.cost}></TextField>
</Grid>
<Grid>
    <Typography>Quantity</Typography>
    <TextField disabled={itemData != null ? false : true} 
    value={itemData?.quantity}
    onChange={(event) => {handleQuantity(event.target.value)}
}
    ></TextField>
</Grid>
<Grid>
    <Button onClick={() => {addToCart()}}>Add to Cart</Button>
</Grid>

<TableContainer > 
<TableHead>
    <TableRow>
        <TableCell align='right'>Id</TableCell>
        <TableCell align='right'>Name</TableCell>
        <TableCell align='right'>Cost</TableCell>
        <TableCell align='right'>Quantity</TableCell>
        <TableCell align='right'></TableCell>
    </TableRow>
    </TableHead>
    <TableBody >
    {itemList?.map((item) =>
    (
        
        <TableRow key={item.id}>
            <TableCell align='right'> {item.id}</TableCell>
            <TableCell align='right'> {item.name}</TableCell>
            <TableCell align='right'> {item.cost}</TableCell>
            <TableCell align='right'> {item.quantity}</TableCell>
            <TableCell align='right'> <Button onClick={(event) => deleteItem(item.id)}>Delete</Button></TableCell>
        </TableRow>
    ))}
    </TableBody>

</TableContainer>
<Button>Save</Button>
            </Container>
        </>
    );
}

export default App;