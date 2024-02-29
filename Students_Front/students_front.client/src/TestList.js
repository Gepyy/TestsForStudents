import React, { useState, useEffect } from 'react';

const TestList = ({ token }) => {
  const [tests, setTests] = useState([]);

  useEffect(() => {
    const fetchTests = async () => {
      const response = await fetch('/api/tests', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      if (response.ok) {
        const data = await response.json();
        setTests(data);
      }
    };

    fetchTests();
  }, [token]);

  return (
    <div>
      <h2>Tests</h2>
      <ul>
        {tests.map((test) => (
          <li key={test.id}>
            <h3>{test.title}</h3>
            <p>{test.description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TestList;
