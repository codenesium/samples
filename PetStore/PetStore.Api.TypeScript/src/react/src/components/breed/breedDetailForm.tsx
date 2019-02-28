import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BreedMapper from './breedMapper';
import BreedViewModel from './breedViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {PetTableComponent} from '../shared/petTable'
	



interface BreedDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface BreedDetailComponentState {
  model?: BreedViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class BreedDetailComponent extends React.Component<
BreedDetailComponentProps,
BreedDetailComponentState
> {
  state = {
    model: new BreedViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Breeds + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Breeds +
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
          let response = resp.data as Api.BreedClientResponseModel;

          console.log(response);

          let mapper = new BreedMapper();

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
							<h3>name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>speciesId</h3>
							<p>{String(this.state.model!.speciesIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Pets</h3>
            <PetTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Breeds + '/' + this.state.model!.id + '/' + ApiRoutes.Pets}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedBreedDetailComponent = Form.create({ name: 'Breed Detail' })(
  BreedDetailComponent
);

/*<Codenesium>
    <Hash>5334c87db00225bba575b6e0c424dbba</Hash>
</Codenesium>*/