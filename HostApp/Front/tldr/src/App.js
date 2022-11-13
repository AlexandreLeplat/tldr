import { createRoot } from 'react-dom/client';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import Menu from './components/Menu';
import Navigator from './containers/Navigator';
import reducer from './reducer';
import { createStore, compose } from 'redux';
import 'bootstrap/dist/css/bootstrap.min.css';

const root = createRoot(document.querySelector('.appContainer'));
const composeEnhancers =
	window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__?.({ trace: true }) || compose;
const store = createStore(reducer, composeEnhancers());
root.render(
	<Provider store={store}>
		<BrowserRouter>
			<Menu />
			<Navigator />
		</BrowserRouter>
	</Provider>
);
