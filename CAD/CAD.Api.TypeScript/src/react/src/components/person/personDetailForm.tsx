import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {CallPersonTableComponent} from '../shared/callPersonTable'
	



interface PersonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PersonDetailComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PersonDetailComponent extends React.Component<
PersonDetailComponentProps,
PersonDetailComponentState
> {
  state = {
    model: new PersonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.People + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.People +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PersonClientResponseModel;

          console.log(response);

          let mapper = new PersonMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>firstName</h3>
							<p>{String(this.state.model!.firstName)}</p>
						 </div>
					   						 <div>
							<h3>lastName</h3>
							<p>{String(this.state.model!.lastName)}</p>
						 </div>
					   						 <div>
							<h3>phone</h3>
							<p>{String(this.state.model!.phone)}</p>
						 </div>
					   						 <div>
							<h3>ssn</h3>
							<p>{String(this.state.model!.ssn)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>CallPersons</h3>
            <CallPersonTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.People + '/' + this.state.model!.id + '/' + ApiRoutes.CallPersons}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPersonDetailComponent = Form.create({ name: 'Person Detail' })(
  PersonDetailComponent
);

/*<Codenesium>
    <Hash>f9c0579e923ce82a9cfab0952e3077a7</Hash>
</Codenesium>*/