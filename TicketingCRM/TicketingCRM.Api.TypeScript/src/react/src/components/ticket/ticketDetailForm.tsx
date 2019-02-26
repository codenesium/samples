import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TicketMapper from './ticketMapper';
import TicketViewModel from './ticketViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {SaleTicketTableComponent} from '../shared/saleTicketTable'
	



interface TicketDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TicketDetailComponentState {
  model?: TicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TicketDetailComponent extends React.Component<
TicketDetailComponentProps,
TicketDetailComponentState
> {
  state = {
    model: new TicketViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Tickets + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Tickets +
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
          let response = resp.data as Api.TicketClientResponseModel;

          console.log(response);

          let mapper = new TicketMapper();

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
							<h3>publicId</h3>
							<p>{String(this.state.model!.publicId)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>ticketStatusId</h3>
							<p>{String(this.state.model!.ticketStatusIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>SaleTickets</h3>
            <SaleTicketTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Tickets + '/' + this.state.model!.id + '/' + ApiRoutes.SaleTickets}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTicketDetailComponent = Form.create({ name: 'Ticket Detail' })(
  TicketDetailComponent
);

/*<Codenesium>
    <Hash>4d4b9b185a81e04695b600795319ec31</Hash>
</Codenesium>*/