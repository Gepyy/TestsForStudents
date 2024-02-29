import React, { useState, useEffect } from 'react';
import axios from 'axios';

function TestPage() {
    const [tests, setTests] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        setIsLoading(true);
        try {
            const response = await axios.get('/api/tests');
            setTests(response.data);
        } catch (error) {
            console.error('Error fetching data:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const handleDelete = async (id) => {
        setIsLoading(true);
        try {
            await axios.delete(`/api/tests/${id}`);
            setTests(tests.filter(test => test.id !== id));
        } catch (error) {
            console.error('Error deleting test:', error);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div>
            <h1>Tests</h1>
            {isLoading ? (
                <p>Loading...</p>
            ) : (
                <ul>
                    {tests.map(test => (
                        <li key={test.id}>
                            {test.name} - {test.description}{' '}
                            <button onClick={() => handleDelete(test.id)}>Delete</button>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}

export default TestPage;
