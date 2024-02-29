import React, { useState } from 'react';
import Login from './Login';
import TestList from './TestList';

const App = () => {
  const [token, setToken] = useState('');

  return (
    <div>
      {!token ? <Login setToken={setToken} /> : <TestList token={token} />}
    </div>
  );
};

export default App;
