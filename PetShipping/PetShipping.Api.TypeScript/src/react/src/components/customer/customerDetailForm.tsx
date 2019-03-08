import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {CustomerCommunicationTableComponent} from '../shared/customerCommunicationTable'
	



interface CustomerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CustomerDetailComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CustomerDetailComponent extends React.Component<
CustomerDetailComponentProps,
CustomerDetailComponentState
> {
  state = {
    model: new CustomerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Customers + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Customers +
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
          let response = resp.data as Api.CustomerClientResponseModel;

          console.log(response);

          let mapper = new CustomerMapper();

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
							<h3>email</h3>
							<p>{String(this.state.model!.email)}</p>
						 </div>
					   						 <div>
							<h3>firstName</h3>
							<p>{String(this.state.model!.firstName)}</p>
						 </div>
					   						 <div>
							<h3>notes</h3>
							<p>{String(this.state.model!.note)}</p>
						 </div>
					   						 <div>
							<h3>phone</h3>
							<p>{String(this.state.model!.phone)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>CustomerCommunications</h3>
            <CustomerCommunicationTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Customers + '/' + this.state.model!.id + '/' + ApiRoutes.CustomerCommunications}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedCustomerDetailComponent = Form.create({ name: 'Customer Detail' })(
  CustomerDetailComponent
);

/*<Codenesium>
    <Hash>d07fce84b7ce09840a5e57ae80effd85</Hash>
</Codenesium>*/