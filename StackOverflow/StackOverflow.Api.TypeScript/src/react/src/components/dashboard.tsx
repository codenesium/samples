import * as React from 'react';
import axios, { AxiosError, AxiosResponse} from 'axios';
import { Constants, AuthClientRoutes } from '../constants';
import { Alert, Input, Button } from 'antd'
import * as GlobalUtilities from '../lib/globalUtilities';

interface DashboardComponentProps {
  history: any;
  match: any;
}

interface DashboardComponentState {
  connected:boolean;
  connecting:boolean;
  authToken:string | null;
  tokenSubmitted:boolean;
  getDecodedToken:() => string;
}

export default class Dashboard extends React.Component<DashboardComponentProps, DashboardComponentState>  {
  
  state = ({connected:false, 
    connecting:false, 
    tokenSubmitted:false,
    authToken:window.localStorage.getItem('authToken'),
    getDecodedToken: () =>
    {
        return GlobalUtilities.parseJWT(this.state.authToken || '');
    }});

  testConnection() {
    this.setState({...this.state,connecting:true});

    axios.get(Constants.ApiHealthEndpoint, {
      headers: GlobalUtilities.defaultHeaders(),
    })
    .then(
      response => {
		GlobalUtilities.logInfo(response);
        this.setState({connecting:false, connected:true});

      })
	  .catch((error:AxiosError) => {
          GlobalUtilities.logError(error);
	      this.setState({connecting:false, connected:false});
      });
  }

  updateToken = (token:string) =>
  {
     window.localStorage.setItem('authToken', '')
     this.setState({...this.state, authToken:token.replace('Bearer', '').trim(), tokenSubmitted:false});
  }

  updateTokenInLocalStorage = () =>
  {
    window.localStorage.setItem('authToken', this.state.authToken || '')
    this.setState({...this.state, tokenSubmitted:true});
  }

  componentDidMount()
  {
     if( !localStorage.getItem('authToken'))
     {
        this.props.history.push(AuthClientRoutes.Login);
     }

     this.testConnection();
  }

  render() {
      let alert:JSX.Element = <div></div>;
      if(this.state.connecting){
        alert = <Alert message='Connecting...' type='info' />;
      }
      else if(this.state.connected){
        alert = <Alert message='Connected...' type='success' />;
      }
      else {
        alert = <Alert message='Unable to connect to API...' type='warning' />;
      }

      return <div>
        {alert}
        <br />
		<Button><a href={Constants.ApiHealthEndpoint} target='_blank'>API Health</a></Button>
		<Button><a href={Constants.SwaggerEndpoint} target='_blank'>Swagger</a></Button>
        <div style={{'marginTop':'35px'}} > 
            <label htmlFor='authToken'>Auth Token</label>
            <Input.Search 
              name='authToken' 
              placeholder={'Auth Token'} 
              key={'updateTokenInput'}
              value={this.state.authToken || ''}
              enterButton='Update Token'
              onChange={(e) => 
              {
                this.updateToken(e.target.value);
              }}
              onSearch={() => 
              { 
                this.updateTokenInLocalStorage();
              }}
              
            />
            <br />
            <br />
              {this.state.tokenSubmitted ? <Alert message='Token Updated...' type='success' /> : <div></div> }
            <br />
            <pre> 
             {JSON.stringify(this.state.getDecodedToken(), null, 2)}
            </pre>
       </div>
      </div>;
  }
}