import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PetMapper from './petMapper';
import PetViewModel from './petViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface PetDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PetDetailComponentState {
  model?: PetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PetDetailComponent extends React.Component<
PetDetailComponentProps,
PetDetailComponentState
> {
  state = {
    model: new PetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Pets + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Pets +
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
          let response = resp.data as Api.PetClientResponseModel;

          console.log(response);

          let mapper = new PetMapper();

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
							<h3>Acquired Date</h3>
							<p>{String(this.state.model!.acquiredDate)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>Breed</h3>
							<p>{String(this.state.model!.breedIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>Description</h3>
							<p>{String(this.state.model!.description)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>Pen</h3>
							<p>{String(this.state.model!.penIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>Price</h3>
							<p>{String(this.state.model!.price)}</p>
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

export const WrappedPetDetailComponent = Form.create({ name: 'Pet Detail' })(
  PetDetailComponent
);

/*<Codenesium>
    <Hash>d35bf920a69e72ebcbf24deaa3f387e0</Hash>
</Codenesium>*/