import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './Login';
import TestPage from './TestPage';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/tests" element={<TestPage />} />
            </Routes>
        </Router>
    );
}

export default App;
