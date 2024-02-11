import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { ConvertApiService } from "./services/ConvertApiService";
import React, { useState } from 'react';
import { Navbar, Container, Form, Button, Card, Alert } from 'react-bootstrap';

function App() {

  const [numberInput, setNumberInput] = useState(0);
  const [convertedWords, setConvertedWords] = useState(null);
  const [showAlert, setShowAlert] = useState(false);

  async function handleSubmit(e) {
    e.preventDefault();
    if (!isNaN(numberInput)) {
      let result = await ConvertApiService.convertToWordsApi(numberInput);
      setConvertedWords(result);
    } else {
      handleInvalidInput();
    }
  }

  function handleInvalidInput() {
    setShowAlert(true);
    setTimeout(() => {
      setShowAlert(false);
    }, 5000);
  }

  return (
    <div className="App">
      <Navbar className="bg-body-tertiary">
        <Container>
          <Navbar.Brand href="/">Number To Words Converter</Navbar.Brand>
        </Container>
      </Navbar>

      <Container className="mt-4">
        <Card>
          <Card.Body>
            <h2>Welcome to our Number to Words Converter!</h2>
            <p>
              Our application simplifies the process of converting numbers into words effortlessly. Whether you're dealing
              with financial documents, writing checks, or simply exploring linguistic curiosity, our tool offers a seamless solution.
            </p>
            <p>
              To get started, simply input your numeric value into the designated field and click "Convert." Within moments,
              you'll receive the corresponding words for your number, allowing for clear communication and precise documentation.
            </p>
            <p>
              Experience the convenience of transforming numerical data into expressive language with ease. Start using our
              Number to Words Converter today!
            </p>
          </Card.Body>
        </Card>

        <Form className="mt-4" onSubmit={handleSubmit}>
          <Form.Group className='row' controlId="formNumberInput">
            <Form.Label column sm="4" className="text-end">
              Input Number To Convert:
            </Form.Label>
            <div className="col-sm-6">
              <Form.Control
                type="number"
                placeholder="0"
                value={numberInput}
                onChange={(e) => setNumberInput(e.target.value)}
              />
            </div>
            <div className="col-sm-2">
              <Button variant="primary" type="submit">
                Convert
              </Button>
            </div>
          </Form.Group>
        </Form>

        <div className="mt-5">
          <h4>Converted Result:</h4>
          {convertedWords && (
            <p>{convertedWords}</p>
          )}
        </div>

        {showAlert && (
          <Alert variant="danger" className="mt-4">
            Please enter a valid number.
          </Alert>
        )}

      </Container>
    </div>
  );
}

export default App;
