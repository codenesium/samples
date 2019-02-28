import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VPersonMapper from './vPersonMapper';
import VPersonViewModel from './vPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface VPersonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VPersonDetailComponentState {
  model?: VPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VPersonDetailComponent extends React.Component<
VPersonDetailComponentProps,
VPersonDetailComponentState
> {
  state = {
    model: new VPersonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.VPersons + '/edit/' + this.state.model!.personId);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.VPersons +
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
          let response = resp.data as Api.VPersonClientResponseModel;

          console.log(response);

          let mapper = new VPersonMapper();

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
							<h3>PersonId</h3>
							<p>{String(this.state.model!.personId)}</p>
						 </div>
					   						 <div>
							<h3>PersonName</h3>
							<p>{String(this.state.model!.personName)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedVPersonDetailComponent = Form.create({ name: 'VPerson Detail' })(
  VPersonDetailComponent
);

/*<Codenesium>
    <Hash>4bcc2989d8f065d600e14fa59b674ac0</Hash>
</Codenesium>*/